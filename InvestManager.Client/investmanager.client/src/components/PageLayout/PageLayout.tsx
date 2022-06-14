import React from "react";
import "./PageLayout.style.css"
import {TopBar} from "./TopBar/TopBar";

export type PageLayoutProps = {
    isAuthorized: boolean;
    userName: string;
    onAuthorize: (authorized: boolean, email: string) => void;
    childs?: JSX.Element[];
};

export class PageLayout extends React.Component<PageLayoutProps, {}>{
    render() {
        return (
            <div className="container">
                <TopBar isAuthorized={this.props.isAuthorized} userName={this.props.userName} onAuthorize={this.props.onAuthorize}/>
                {this.props.childs}
            </div>
        );
    }
}
