import React from "react";
import "./NoteItem.styles.css"
import {Note} from "../../../../../types/Note";

export type NoteItemProps = {
    note: Note;
    onClick: (note: Note) => void;
    activeNoteId: string;
};

export class NoteItem extends React.Component<NoteItemProps>{
    render() {
        const note = this.props.note;

        return (
            <li className={this.props.activeNoteId === this.props.note.id ? "active-note-container" : ""} onClick={() => this.props.onClick(this.props.note)}>
                <div className="note-item-container">
                    <div className="left-tile-container">
                        <p className="symbol-container">{note.symbol}</p>
                        <p className="date-container">{formatDateString(note.createDate)}</p>
                    </div>

                    <p className="text-container">{note.text}</p>
                </div>
            </li>
        );
    }
}

const formatDateString = (dateString: string) => new Date(dateString).toLocaleDateString();