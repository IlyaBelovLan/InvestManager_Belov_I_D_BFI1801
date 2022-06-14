import React from "react";
import "./RightPanel.style.css";
import {Note} from "../../../types/Note";
import {client} from "../../../client/InvestManagerClient";
import {NotesList} from "./Notes/NotesList";

export type RightPanelProps = {
    isAuthorized: boolean;
    currentSymbol: string;
    onNoteClick: (note: Note) => void;
    activeNoteId: string;
};

export type RightPanelState = {
    notes: Note[];
    notesTotalCount: number;
};

export class RightPanel extends React.Component<RightPanelProps, RightPanelState>{

    constructor(props: RightPanelProps) {
        super(props);

        this.state = {
            notes: [],
            notesTotalCount: 0
        };
    }

    loadNotes = async (symbol: string) => {
        const response = await client.getNotes({symbol});
        const notes = response.notes!.map(note => {
            const myNote: Note = {
                id: note.id as string,
                symbol: note.symbol as string,
                text: note.text as string,
                createDate: note.createDate as string
            };
            return myNote;
        })
            .sort((left, right) => {
                if(left.createDate === right.createDate)
                    return 0;
                return left.createDate > right.createDate ? -1 : 1;
            });
        const notesTotalCount = response.count as number;

        this.setState({notes, notesTotalCount});
    }

    handleOnNoteCreate = async (text: string) => {
        await client.createNote({symbol: this.props.currentSymbol, text});
        await this.loadNotes(this.props.currentSymbol);
    }

    async componentWillReceiveProps(nextProps: Readonly<RightPanelProps>, nextContext: any) {
        if(nextProps.isAuthorized){
            await this.loadNotes(nextProps.currentSymbol);
        }
    }

    render() {
        if (this.props.isAuthorized)
        {
            return (
                <div className="right-panel-container">
                    <NotesList
                        currentSymbol={this.props.currentSymbol}
                        onNoteCreate={this.handleOnNoteCreate}
                        notes={this.state.notes}
                        totalCount={this.state.notesTotalCount}
                        onNoteClick={this.props.onNoteClick}
                        activeNoteId={this.props.activeNoteId}
                    />
                </div>
            );
        }
        else
        {
            return (
                <div className="right-panel-container">
                    <div className="need-authorize-container">
                        {"Для просмотра заметок авторизируйтесь"}
                    </div>
                </div>
            );
        }
    }
}
