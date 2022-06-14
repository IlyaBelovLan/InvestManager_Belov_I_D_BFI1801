import React from "react";
import "./Item.styles.css"
import {StockInfo} from "../../../../../types/StockInfo";

export type itemProps = {
    stockInfo: StockInfo;
    onClick: (info: StockInfo) => void;
    activeSymbol: string;
};

export class Item extends React.Component<itemProps>{
    render() {
        const info = this.props.stockInfo;

        return (
            <li className={this.props.activeSymbol === this.props.stockInfo.symbol ? "active-symbol-container" : ""} onClick={() => this.props.onClick(info)}>
                <div className="item-container">
                    <p className="item-container-left-tile">{info.name}</p>
                    <p className="item-container-right-tile">{info.currency}</p>
                </div>
            </li>
        );
    }
}