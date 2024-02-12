import { makeAutoObservable} from "mobx";

class AuthStore {
    token = "";

    constructor() {
        makeAutoObservable(this);
    }

    updateToken(newToken: string) {
        this.token = newToken;
    }
}

export default AuthStore;