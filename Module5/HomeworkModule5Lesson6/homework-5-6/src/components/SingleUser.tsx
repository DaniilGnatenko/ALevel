import { ReactElement, FC, useState } from "react";
import { Box, Button, Card, CardActions, CardContent, CardMedia, CircularProgress, Typography, } from '@mui/material';
import { IReqresUserResponse } from "../models/reqres-response.model";
import axios from "axios";

const Reqres = "https://reqres.in/"

const SingleUser: FC<any> = (): ReactElement => {

    const [reqresResponse, setReqresResponse] = useState<IReqresUserResponse | null>(null)


    axios.get<IReqresUserResponse>(`${Reqres}api/users/2`)
        .then(response => setReqresResponse(response.data))


    return (
        <Box sx={{
            flexGrow: 1,
            backgroundColor: 'whitesmoke',
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center'
        }}>
            {reqresResponse ?
                <Card sx={{ minWidth: 125 }}>
                    <CardMedia
                        sx={{ height: 250 }}
                        image={reqresResponse.data.avatar}
                        title={reqresResponse.data.first_name}
                    />
                    <CardContent>
                        <Typography variant="h5" component="div">
                            {reqresResponse.data.first_name} {reqresResponse.data.last_name}
                        </Typography>
                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                            ID: {reqresResponse.data.id}
                        </Typography>
                    </CardContent>
                    <CardActions>
                        <Button size="small">{reqresResponse.data.email}</Button>
                    </CardActions>
                </Card> :
                <CircularProgress />
            }
        </Box>
    );
};

export default SingleUser;