import React from "react";
import {CurrentPriceDisplay} from "./CurrentPriceDisplay/CurrentPriceDisplay";
import {StockLineChart} from "./StockLineChart/StockLineChart";
import {DatePeriodSelector} from "./DatePeriodSelector/DatePeriodSelector";
import "./CentralPanel.style.css";
import {NoteDisplay} from "./NoteDisplay/NoteDisplay";
import {Header} from "../../Header/Header";
import {DatePeriod} from "../../../client/client";
import {Note} from "../../../types/Note";
import {StockInfo} from "../../../types/StockInfo";

export type CentralPanelProps = {
    stockInfo: StockInfo | null;
    note: Note | null;
};

export type CentralPanelState = {
    datePeriod: DatePeriod
}

export class CentralPanel extends React.Component<CentralPanelProps, CentralPanelState>{
    constructor(props: CentralPanelProps) {
        super(props);

        this.state = {
            datePeriod: DatePeriod.Day
        };
    }

    render() {
        const info = this.props.stockInfo;

            if(info === null)
                return <div/>;
            else{
                return (
                    <div className="central-panel-container">
                        <div className="central-panel-info-container">
                            <div className="central-panel-header-container">
                                <Header header={info.name}/>
                            </div>
                            <div className="current-price-display-container">
                                <CurrentPriceDisplay symbol={info.symbol} exchange={info.exchange} currency={info.currency}/>
                            </div>
                            <div>
                                <DatePeriodSelector onChange={(datePeriod) => this.setState({datePeriod})}/>
                            </div>
                        </div>
                        <div className="chart-container">
                            <StockLineChart datePeriod={this.state.datePeriod} stockInfo={this.props.stockInfo}/>
                        </div>
                        <div>
                            <NoteDisplay note={this.props.note}/>
                        </div>
                    </div>
                );
            }
    }
}