import React from "react";
import "./UserInfoBlock.style.css"
import swal from "sweetalert";
import {executeWithExceptionHandling} from "../../../App/@services/utils";
import {client} from "../../../../client/InvestManagerClient";

export type UserInfoBlockProps = {
    isAuthorized: boolean;
    userName: string;
    onAuthorize: (authorized: boolean, email: string) => void;
}

export type UserInfoBlockState = {
    wantToRegister: boolean;
    wantToLogIn: boolean;
};

export class UserInfoBlock extends React.Component<UserInfoBlockProps, UserInfoBlockState>{
    constructor(props: UserInfoBlockProps) {
        super(props);

        this.state = {
            wantToRegister: false,
            wantToLogIn: false
        }
    }

    onLogInButtonClick = async () => {
        const [email, password] = await swalLogIn();

        // TODO: Может все таки исключения?
        if(email === null || password === null)
            return;

        await executeWithExceptionHandling(async () => {
            const logInResponse = await client.logIn({email, passwordHash: password});
            client.setAuthToken(logInResponse.accessToken as string);

            const decodedPayload = parseJwt(logInResponse.accessToken as string);
            this.props.onAuthorize(true, decodedPayload.UserName);
        });
    };

    onRegisterButtonClick = async () => {
        const [userName, email, password] = await swalRegister();

        // TODO: Может все таки исключения?
        if(userName === null || email === null || password === null)
            return;

        await executeWithExceptionHandling(async () => {
            const logInResponse = await client.registerUser({userName, email, passwordHash: password });
            client.setAuthToken(logInResponse.accessToken as string);

            const decodedPayload = parseJwt(logInResponse.accessToken as string);
            this.props.onAuthorize(true, decodedPayload.UserName);
        });
    };

    render() {
        if(this.props.isAuthorized){
            return (
                <div className="user-info-container">
                    <div className="user-info">{this.props.userName}</div>
                    <button color={"#fff"} onClick={() => {
                        this.props.onAuthorize(false, "");
                        this.setState({wantToRegister: false, wantToLogIn: false});
                    }}>
                        Выйти
                    </button>
                </div>
            );
        }

        return (
            <div className="user-info-container">
                <button onClick={this.onRegisterButtonClick}>Зарегистрироваться</button>
                <button onClick={this.onLogInButtonClick}>Войти</button>
            </div>
        );
    }
}

const swalRegister = async () => {
    let userName : string | null = null;
    let email : string | null = null;
    let password : string | null = null;

    await swal( {
        title: "Форма регистрации:",
        text: "Введите имя пользователя",
        content: {element: "input"},
    })
        .then((value) => userName = value);

    if(userName == null)
        return [null, null];

    await swal({
        title: "Форма регистрации:",
        text: "Введите адрес электронной почты:",
        content: {element: "input"},
    })
        .then((value) => email = value);

    if(email == null)
        return [null, null];

    await swal({
        title: "Форма регистрации:",
        text: "Введите пароль:",
        content: {element: "input", attributes: {type: "password"}},
    })
        .then((value) => password = value)

    if(password == null)
        return [null, null];

    return [userName, email, password];
}

const swalLogIn = async () => {
    let email : string | null = null;
    let password : string | null = null;

    await swal({
        title: "Форма авторизации:",
        text: "Введите адрес электронной почты:",
        content: {element: "input"},
        buttons: ["Отмена", true]
    })
        .then((value) => email = value);

    if(email == null)
        return [null, null];

    await swal( {
        title: "Форма авторизации:",
        text: "Введите пароль:",
        content: {element: "input", attributes: {type: "password"}},
        buttons: ["Отмена", true]
    })
        .then((value) => password = value)

    if(password == null)
        return [null, null];

    return [email, password];
}

const parseJwt = (token: string) => {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};