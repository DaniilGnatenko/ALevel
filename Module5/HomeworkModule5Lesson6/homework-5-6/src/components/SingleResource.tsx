import { Box, Card, CardContent, Typography, CardActions, Button, CircularProgress } from "@mui/material";
import axios from "axios";
import { FC, ReactElement, useState } from "react";
import { IReqresResourceResponse } from "../models/reqres-response.model";

const Reqres = "https://reqres.in/"

const SingleResource: FC<any> = (): ReactElement => {

    const [reqresResponse, setReqresResponse] = useState<IReqresResourceResponse | null>(null)


    axios.get<IReqresResourceResponse>(`${Reqres}api/unknown/2`)
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
                <Card sx={{ minWidth: 125, backgroundColor: `${reqresResponse.data.color}` }}>
                    <CardContent>
                        <Typography variant="h5" component="div">
                            Name: {reqresResponse.data.name} Year: {reqresResponse.data.year}
                        </Typography>
                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                            ID: {reqresResponse.data.id}
                        </Typography>
                    </CardContent>
                    <CardActions>
                        <Button size="small">{reqresResponse.data.pantone_value}</Button>
                    </CardActions>
                </Card> :
                <CircularProgress />
            }
        </Box>
    );
};
export default SingleResource;