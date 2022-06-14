import React from "react";
import {StockInfo} from "../../types/StockInfo";
import "./App.style.css"
import {CentralPanel} from "./CentralPanel/CentralPanel";
import {RightPanel} from "./RightPanel/RightPanel";
import {LeftPanel} from "./LeftPanel/LeftPanel";
import {Note} from "../../types/Note";
import {PageLayout} from "../PageLayout/PageLayout";

export type AppState = {
    currentStockInfo: StockInfo | null;
    isAuthorized: boolean;
    userName: string;
    currentNote: Note | null;

    activeSymbol: string;
    activeNoteId: string;
};

export class App extends React.Component<{}, AppState>{

    constructor(props: {}) {
        super(props);

        this.state = {
            currentStockInfo: null,
            isAuthorized: false,
            userName: "",
            currentNote: null,
            activeSymbol: "",
            activeNoteId: ""
        };

        setInterval(() => this.setState({isAuthorized: false, userName: "" , currentNote: null, activeNoteId: ""}), 60 * 60 * 1000)
    }

    handleStocksListItemClick = (info: StockInfo) => this.setState({currentStockInfo: info, activeSymbol: info.symbol, currentNote: null});

    handleAuthorizeOnSubmit = async (isAuthorized: boolean, userName: string) => {
        if(!isAuthorized){
            this.setState({isAuthorized, userName: "" , currentNote: null, activeNoteId: ""});
        }
        else{
            this.setState({isAuthorized, userName});
        }
    }

    handleOnNoteClick = (note: Note) => {
        if(this.state.currentStockInfo === null)
            return;
        this.setState({currentNote: note, activeNoteId: note.id});
    };

    render(){
        return (
            <div className="app">
                <PageLayout
                    isAuthorized={this.state.isAuthorized}
                    userName={this.state.userName}
                    onAuthorize={(authorized: boolean, email: string) => this.handleAuthorizeOnSubmit(authorized, email)}
                    childs = {
                    [
                        <LeftPanel onItemClick={this.handleStocksListItemClick} activeSymbol={this.state.activeSymbol}/>,
                        <CentralPanel stockInfo={this.state.currentStockInfo} note={this.state.currentNote}/>,
                        <RightPanel
                            isAuthorized={this.state.isAuthorized}
                            currentSymbol={this.state.currentStockInfo?.symbol as string}
                            onNoteClick={this.handleOnNoteClick}
                            activeNoteId={this.state.activeNoteId}/>
                    ]
                }/>
            </div>
        );
    }
}