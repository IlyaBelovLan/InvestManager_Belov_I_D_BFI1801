import React from "react";

import "./StocksList.styles.css"
import {Item} from "./Item/Item";
import {StockInfo} from "../../../../types/StockInfo";

export type StocksListProps = {
    stocksInfos: StockInfo[];
    onItemClick: (info: StockInfo) => void;
    activeSymbol: string;
};

export class StocksList extends React.Component<StocksListProps, any>{
    render() {
        if(this.props.stocksInfos === null || this.props.stocksInfos.length === 0)
            return <div>{"Нет доступных активов"}</div>

        return (
                <div className="stock-list-container">
                    <ul>
                        {this.props.stocksInfos.map(info =>
                            <Item
                                key={info.symbol + info.exchange}
                                activeSymbol={this.props.activeSymbol}
                                stockInfo={info}
                                onClick={this.props.onItemClick}
                            />)
                        }
                    </ul>
                </div>
        );
    }
}