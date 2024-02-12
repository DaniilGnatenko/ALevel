import { ReactElement, FC, useState, useContext } from "react";
import { Box, Button, CircularProgress, TextField, Typography } from '@mui/material';
import { IAccountInfo } from "../../models/accountInfo.model";
import axios from "axios";
import { ISignInResponse } from "../../models/accountInfoResponse.model";
import { AppStoreContext } from "../../App";
import { observer } from "mobx-react-lite";


const Reqres = "https://reqres.in/"

const Login: FC<any> = (): ReactElement => {

    const appStore = useContext(AppStoreContext);

    const [accountInfo, setAccountInfo] = useState<IAccountInfo>({
        email: "",
        password: ""
    });

    const [loginResponse, setLoginResponse] = useState<ISignInResponse>();

    const loginHandler = () => {
             axios.post(`${Reqres}api/login`, accountInfo)
            .then(response => {
                console.log(response.data);
                setLoginResponse(response.data);
                appStore.authStore.updateToken(response.data.token)
                console.log(appStore.authStore.token);
            }) 
    };

    return (
        <Box
            sx={{
                marginTop: 8,
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
            }}
        >
            <Typography component="h1" variant="h5">
                Sign in
            </Typography>
            <Box component="form" 
                onSubmit={(event) => {
                    event.preventDefault()
                    loginHandler();
                }}
                noValidate sx={{ mt: 1 }}>
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    id="email"
                    label="Email Address"
                    name="email"
                    autoComplete="email"
                    onChange={(ev) => setAccountInfo(prevState => {
                        return { ...prevState, email: ev.target.value }
                    })}
                    autoFocus
                />
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    name="password"
                    label="Password"
                    type="password"
                    id="password"
                    onChange={(ev) => setAccountInfo(prevState => {
                        return { ...prevState, password: ev.target.value }
                    })}
                    autoComplete="current-password"
                />

                <Button
                    type="submit"
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                >
                    'Submit'
                </Button>
                {appStore.authStore.token ?
                    <p className="mt-3 mb-3" style={{ color: 'green', fontSize: 14, fontWeight: 700 }}>{`Success! Token is: ${appStore.authStore.token}`}</p>
                    :
                    <CircularProgress />
                }
            </Box>
        </Box>
    )
};

export default observer(Login);