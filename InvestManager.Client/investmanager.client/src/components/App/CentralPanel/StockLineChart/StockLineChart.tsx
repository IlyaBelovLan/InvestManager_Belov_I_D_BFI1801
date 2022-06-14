import React, {Component} from "react";
import {Chart} from "react-google-charts";
import "./StockLineChart.style.css";
import {DatePeriod} from "../../../../client/client";
import {client} from "../../../../client/InvestManagerClient";
import {StockInfo} from "../../../../types/StockInfo";

export type StockLineChartProps = {
    stockInfo: StockInfo | null;
    datePeriod: DatePeriod
}

export type LineChartItem = {
    dateTime: Date,
    closePrice: number
}

export type StockLineChartState = {
    items: LineChartItem[];
}

export class StockLineChart extends Component<StockLineChartProps, StockLineChartState>{

    constructor(props: StockLineChartProps) {
        super(props);

        this.state = {
            items: []
        }
    }

    loadPrices = async (info: StockInfo, datePeriod: DatePeriod) =>{
        try {
            const response = await client.getPriceChart({symbol: info.symbol, exchange: info.exchange, datePeriod: datePeriod});
            const items = response.chartItems!.map((chartItem) => {
                return {
                    dateTime: new Date(chartItem.datetime as string),
                    closePrice: parseFloat(chartItem.close as string)
                };

            });

            this.setState({items});
        }
        catch
        {
            this.setState({items: [{dateTime: new Date(), closePrice: 0}]});
        }
    }

    async componentWillReceiveProps(nextProps: Readonly<StockLineChartProps>, nextContext: any) {
        const info = nextProps.stockInfo as StockInfo;

        if(info === null)
            return;

        await this.loadPrices(info, nextProps.datePeriod);
    }

    async componentDidMount() {
        const info = this.props.stockInfo as StockInfo;

        if(info === null)
            return;

        await this.loadPrices(info, this.props.datePeriod);
    }

    getTitle = () => {
        const info = this.props.stockInfo as StockInfo;
        return `График компании "${info.name}"` + (this.state.items.length <= 1 ? " - не доступен за выбранный период" : "");
    };

    render() {

        const data : any[] = [
            [
                { type: "date", label: `${this.props.stockInfo?.name}` },
                { type: "number"}
            ]
        ].concat(this.state.items.map((item) => [item.dateTime, item.closePrice] as any));

        const options = {
            legend: { position: "none" },
            chart: {
                title: this.getTitle(),
            },
            width: 850,
            height: 500,
            series: {
                0: { axis: "Prices" },
            },
            axes: {
                y: {
                    Prices: { label: `Стоимость акции (${this.props.stockInfo?.currency})` },
                },
            },
        };

        return (
            <div>
                {
                    this.state.items.length === 0
                        ? <></>
                        : <div className="line-chart-container">
                            <Chart
                                chartType="Line"
                                data={data}
                                options={options}
                                formatters={[
                                    {
                                        column: 0,
                                        type: "DateFormat",
                                        options: {
                                            pattern: `dd.MM.yyyy HH:mm`
                                        }
                                    },
                                    {
                                        column: 1,
                                        type: "NumberFormat",
                                        options: {
                                            fractionDigits: 2, suffix: ` ${this.props.stockInfo?.currency}`
                                        }
                                    }
                                ]}
                            />
                        </div>}
            </div>
        );
    }
}