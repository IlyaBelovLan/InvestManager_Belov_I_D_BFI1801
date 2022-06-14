import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import "./components/App/App.gstyle.css"
import {App} from "./components/App/App";

export const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

root.render(<App/>);
