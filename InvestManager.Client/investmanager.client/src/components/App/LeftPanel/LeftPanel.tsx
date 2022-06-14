import React from "react";
import {StocksList} from "./StocksList/StocksList";
import {SearchSymbolsField} from "./SearchSymbolsField/SearchSymbolsField";
import "./LeftPanel.style.css"
import {client} from "../../../client/InvestManagerClient";
import {StockInfo} from "../../../types/StockInfo";
import {ExchangeSelector} from "./StocksList/ExchangeSelector/ExchangeSelector";

export type LeftPanelProps = {
    onItemClick: (info: StockInfo) => void;
    activeSymbol: string;
};

export type LeftPanelState = {
    stockInfos: StockInfo[];
};

export class LeftPanel extends React.Component<LeftPanelProps, LeftPanelState>{

    constructor(props: LeftPanelProps) {
        super(props);

        this.state = {
            stockInfos: []
        };
    }

    loadStockInfos = async (exchange: string) =>{
        const response = await client.getStocksList({exchange});

        const stockInfos = response.stocksInfos!.map(info => {
            const stockInfo : StockInfo =  {
                symbol: info.symbol as string,
                name: info.name as string,
                currency: info.currency as string,
                exchange: info.exchange as string,
                country: info.country as string,
                type: info.type as string
            };
            return stockInfo;
        });
        this.setState({ stockInfos });
    }

    onSubmitSearchHandle = async (symbol: string) =>{
        const response = await client.searchSymbols({symbol, outputSize: 1000});

        const stockInfos = response.data!.map(info => {
            const stockInfo : StockInfo =  {
                symbol: info.symbol as string,
                name: info.instrumentName as string,
                currency: info.currency as string,
                exchange: info.exchange as string,
                country: info.country as string,
                type: info.instrumentType as string
            };
            return stockInfo;
        });
        this.setState({ stockInfos });
    }

    onSelectorChange = async (exchange: string) => {
        await this.loadStockInfos(exchange);
    }

    async componentDidMount() {
        await this.loadStockInfos("NASDAQ");
    }

    render() {
        return (
            <div className="left-panel-container">
                <div className="header-container">
                    <SearchSymbolsField onSubmit={this.onSubmitSearchHandle}/>
                    <ExchangeSelector onChange={this.onSelectorChange}/>
                </div>
                <StocksList activeSymbol={this.props.activeSymbol} stocksInfos={this.state.stockInfos} onItemClick={this.props.onItemClick}/>
            </div>
        );
    }
}