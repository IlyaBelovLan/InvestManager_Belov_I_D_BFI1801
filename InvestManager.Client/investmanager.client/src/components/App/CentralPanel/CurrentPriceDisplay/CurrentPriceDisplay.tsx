import React, {Component} from "react";
import "./CurrentPriceDisplay.style.css";
import {client} from "../../../../client/InvestManagerClient";

export type CurrentPriceDisplayProps = {
    symbol: string;
    exchange: string;
    currency: string;
}

export type CurrentPriceDisplayState = {
    currentPrice: string;
    updateTimerId: number;
};

export class CurrentPriceDisplay extends Component<CurrentPriceDisplayProps, CurrentPriceDisplayState>{
    constructor(props: CurrentPriceDisplayProps) {
        super(props);

        this.state = {
          currentPrice: "",
          updateTimerId: 0
        };
    }

    async componentDidMount() {
        await this.updatePrice(this.props.symbol, this.props.exchange);
        const timeId = window.setInterval(() => this.updatePrice(this.props.symbol, this.props.exchange), 60_000);
        this.setState({updateTimerId: timeId});
    }

    componentWillUnmount() {
        window.clearInterval(this.state.updateTimerId);
    }

    async componentWillReceiveProps(nextProps: Readonly<CurrentPriceDisplayProps>, nextContext: any) {
        await this.updatePrice(nextProps.symbol, nextProps.exchange);
    }

    render() {
        return (<p className="price-display-container">{`Текущая стоимость: ${this.state.currentPrice} ${this.props.currency}`}</p>);
    }

    updatePrice = async (symbol: string, exchange: string) => {
        const response = await client.getCurrentPrice({ symbol, exchange });
        const currentPrice = response.price as string;
        this.setState({currentPrice});
    }
}