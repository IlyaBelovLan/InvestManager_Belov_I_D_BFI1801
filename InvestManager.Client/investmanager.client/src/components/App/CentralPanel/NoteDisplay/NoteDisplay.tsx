import React, {Component} from "react";
import "./NoteDisplay.style.css";
import {Note} from "../../../../types/Note";

type NoteDisplayProps = {
    note: Note | null;
}

export class NoteDisplay extends Component<NoteDisplayProps, any>{
    render() {
        return (
            this.props.note === null
                ? <></>
                : <div className="note-display-container">
                <p>{`Заметка (${formatDateString(this.props.note?.createDate)})`}</p>
                <div className="note-text-container">
                    <textarea value={this.props.note?.text} readOnly={true}/>
                </div>
            </div>
        );
    }
}

const formatDateString = (dateString: string) => new Date(dateString).toLocaleString();