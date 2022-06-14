import React, {Component} from "react";
import "./CreateNoteField.style.css";

export type CreateNoteFieldState = {
    value: string;
};

export type CreateNoteFieldProps = {
    onCreateNote: (text: string) => void;
};

export class CreateNoteField extends Component<CreateNoteFieldProps, CreateNoteFieldState>{
    constructor(props: CreateNoteFieldProps) {
        super(props);

        this.state = {
            value: ""
        };
    }

    handleInputChange = (value: string) => {
        this.setState({value});
    }

    render() {
        return(
            <div>
                <button className="save-button" onClick={(event) => {

                    if(this.state.value === "")
                        return;

                    this.props.onCreateNote(this.state.value);

                    this.setState({value: ""});
                }}>Сохранить</button>

                <textarea
                    className="create-note-input-container"
                    placeholder="Введите текст заметки..."
                    value={this.state.value}
                    onChange={(event) => {
                        this.handleInputChange(event.target.value);
                    }}/>
            </div>
        );
    }
}