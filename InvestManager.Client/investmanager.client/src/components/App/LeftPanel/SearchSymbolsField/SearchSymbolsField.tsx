import React, {Component} from "react";
import "./SearchSymbolsField.style.css";

export type SearchSymbolsFieldProps = {
    onSubmit: (value: string) => void;
};

export type SearchSymbolsFieldState = {
    currentInput: string;
}

export class SearchSymbolsField extends Component<SearchSymbolsFieldProps, SearchSymbolsFieldState>{
    constructor(props: SearchSymbolsFieldProps) {
        super(props);

        this.state = {
            currentInput: ""
        };

    }

    handleChange = (value: string) => {
        this.setState({currentInput: value.toUpperCase()});
    }

    render() {
        return (
            <div className="search-symbols-field-container">
                <div className="symbol-header">
                    Тикер
                </div>
                <form onSubmit={(event) => {
                    event.preventDefault();
                    this.props.onSubmit(this.state.currentInput);
                }}>
                    <input
                        className={"input-container"}
                        type="text"
                        placeholder={"Искать тикер..."}
                        value={this.state.currentInput}
                        onChange={(event) => this.handleChange(event.target.value)}/>
                </form>
            </div>
        );
    }
}