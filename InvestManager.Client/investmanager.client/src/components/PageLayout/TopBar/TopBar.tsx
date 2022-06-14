import React from "react";
import "./TopBar.style.css";
import {UserInfoBlock} from "./UserInfoBlock/UserInfoBlock";

export type TopBarProps = {
    isAuthorized: boolean;
    userName: string;
    onAuthorize: (authorized: boolean, email: string) => void;
}

export class TopBar extends React.Component<TopBarProps>{
    render() {
        return (
            <div className="top-bar-container">
                <div className="stub"/>
                <h1 className="title">Менеджер инвестиций</h1>
                <UserInfoBlock isAuthorized={this.props.isAuthorized} userName={this.props.userName} onAuthorize={this.props.onAuthorize}/>
            </div>
        );
    }
}
