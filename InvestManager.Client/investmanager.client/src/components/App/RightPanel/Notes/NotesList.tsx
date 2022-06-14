import React from "react";
import "./NotesList.styles.css"
import {Note} from "../../../../types/Note";
import {CreateNoteField} from "./CreateNoteField/CreateNoteField";
import {NoteItem} from "./Item/NoteItem";
import {Header} from "../../../Header/Header";

export type NotesListState = {
    currentSymbol: string;
};

export type NotesListProps = {
    notes: Note[];
    totalCount: number;
    currentSymbol: string;
    onNoteCreate: (text: string) => void;
    onNoteClick: (note: Note) => void;
    activeNoteId: string;
};

export class NotesList extends React.Component<NotesListProps, NotesListState> {

    constructor(props: NotesListProps) {
        super(props);

        this.state = {
          currentSymbol: this.props.currentSymbol
        };
    }

    componentWillReceiveProps(nextProps: Readonly<NotesListProps>, nextContext: any) {
        this.setState({currentSymbol: nextProps.currentSymbol});
    }

    render() {
        return (
            <div>
                <div className="notes-header-container">
                    <Header header={`Заметки (${this.props.currentSymbol === undefined ? "все" : this.props.currentSymbol})`}/>
                </div>

                {this.state.currentSymbol === undefined ? <></> : <CreateNoteField onCreateNote={this.props.onNoteCreate}/>}

                <div className={this.state.currentSymbol === undefined ? "notes-list-container-without-note-field" : "notes-list-container"}>
                    <ul>
                        {this.props.notes.map(note =>
                            <NoteItem
                                key={note.id}
                                activeNoteId={this.props.activeNoteId}
                                note={note}
                                onClick={this.props.onNoteClick}
                            />)}
                    </ul>
                </div>
            </div>
        );
    }
}