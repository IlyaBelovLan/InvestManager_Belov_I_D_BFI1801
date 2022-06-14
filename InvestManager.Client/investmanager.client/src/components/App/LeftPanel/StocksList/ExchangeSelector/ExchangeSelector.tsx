import React, {Component} from "react";
import "./ExchangeSelector.style.css";

export type ExchangeSelectorProps = {
    onChange: (exchange: string) => void;
}

export class ExchangeSelector extends Component<ExchangeSelectorProps, any>{
    render() {
        return (
            <div className="exchange-selector-container">
                <div className="exchange-selector-header">
                    Биржа
                </div>
                <div>
                    <select onChange={(event) => this.props.onChange(event.target.value)}>
                        <option value={"NASDAQ"}>NASDAQ</option>
                        <option value={"MOEX"}>MOEX</option>
                        <option value={"LSE"}>LSE</option>
                    </select>
                </div>
            </div>
        );
    }
}