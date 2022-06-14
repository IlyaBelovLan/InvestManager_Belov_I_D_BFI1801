import React, {Component} from "react";
import "./DatePeriodSelector.style.css";
import {DatePeriod} from "../../../../client/client";

export type DatePeriodSelectorProps = {
    onChange: (datePeriod: DatePeriod) => void;
}

export class DatePeriodSelector extends Component<DatePeriodSelectorProps>{

    render() {
        return (
            <div className="date-period-selector-container">
                <p className="period-title-container">Период:</p>
                <select className="period-selector-container" onChange={(event) => this.props.onChange(event.target.value as DatePeriod)}>
                    <option value={DatePeriod.Day}>День</option>
                    <option value={DatePeriod.Week}>Неделя</option>
                    <option value={DatePeriod.Month}>Месяц</option>
                    <option value={DatePeriod.Year}>Год</option>
                    <option value={DatePeriod.FiveYears}>5 лет</option>
                    <option value={DatePeriod.All}>За все время</option>
                </select>
            </div>
        );
    }
}