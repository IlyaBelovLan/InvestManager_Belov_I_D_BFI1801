import React from "react";

export type HeaderProps = {
    header: string;
};

export class Header extends React.Component<HeaderProps>{
    render = () => (
        <h1>{this.props.header}</h1>
    );
}