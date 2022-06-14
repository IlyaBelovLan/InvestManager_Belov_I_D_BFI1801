export class apiBase {
    authToken = '';
    protected constructor() {
    }

    setAuthToken(token: string) {
        this.authToken = token;
    }

    protected transformOptions(options: any): Promise<any> {
        const requestHeaders: HeadersInit = new Headers(options.headers);
        requestHeaders.append('authorization', `Bearer ${this.authToken}`);
        options.headers = requestHeaders;
        return Promise.resolve(options);
    }
}