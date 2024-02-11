import { Paper, Box, Grid, Card, CardContent, Typography, CardActions, Button, CircularProgress, styled } from "@mui/material";
import axios from "axios";
import { FC, ReactElement, useState } from "react";
import { IReqresResourcesResponse } from "../models/reqres-list-response.model";

const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
}));

const Reqres = "https://reqres.in/"

export const ResourcesList: FC<any> = (): ReactElement => {

    const [reqresListResponse, setReqresListResponse] = useState<IReqresResourcesResponse | null>(null)


    axios.get<IReqresResourcesResponse>(`${Reqres}api/unknown`)
        .then(response => setReqresListResponse(response.data))


    return (
        <>
            <Box sx={{
                flexGrow: 1,
                backgroundColor: 'whitesmoke',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center'
            }}>
                <Grid container spacing={6}>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125, backgroundColor: `${reqresListResponse.data[0].color}` }}>
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            Name: {reqresListResponse.data[0].name} Year: {reqresListResponse.data[0].year}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[0].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[0].pantone_value}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125, backgroundColor: `${reqresListResponse.data[1].color}` }}>
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            Name: {reqresListResponse.data[1].name} Year: {reqresListResponse.data[1].year}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[1].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[1].pantone_value}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125, backgroundColor: `${reqresListResponse.data[2].color}` }}>
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            Name: {reqresListResponse.data[2].name} Year: {reqresListResponse.data[2].year}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[2].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[2].pantone_value}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125, backgroundColor: `${reqresListResponse.data[3].color}` }}>
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            Name: {reqresListResponse.data[3].name} Year: {reqresListResponse.data[3].year}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[3].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[3].pantone_value}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125, backgroundColor: `${reqresListResponse.data[4].color}` }}>
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            Name: {reqresListResponse.data[4].name} Year: {reqresListResponse.data[4].year}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[4].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[4].pantone_value}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125, backgroundColor: `${reqresListResponse.data[5].color}` }}>
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            Name: {reqresListResponse.data[5].name} Year: {reqresListResponse.data[5].year}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[5].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[5].pantone_value}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                </Grid>
            </Box>
        </>
    );
};
export default ResourcesList;