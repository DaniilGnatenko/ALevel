import { Box, Button, Card, CardActions, CardContent, CardMedia, CircularProgress, Grid, Pagination, Paper, Typography, styled } from "@mui/material";
import axios from "axios";
import React, { FC, ReactElement, useState } from "react";
import { IReqresUsersResponse } from "../models/reqres-list-response.model";


const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
}));

const Reqres = "https://reqres.in/"

export const UsersList: FC<any> = (): ReactElement => {

    const [page, setPage] = React.useState(1);

    const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
        setPage(value);
    };

    const [reqresListResponse, setReqresListResponse] = useState<IReqresUsersResponse | null>(null)


    axios.get<IReqresUsersResponse>(`${Reqres}api/users?page=${page}`)
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
                <Grid container spacing={6} direction="row"
                    justifyContent="center"
                    alignItems="center">
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125 }}>
                                    <CardMedia
                                        sx={{ height: 125 }}
                                        image={reqresListResponse.data[0].avatar}
                                        title={reqresListResponse.data[0].first_name}
                                    />
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            {reqresListResponse.data[0].first_name} {reqresListResponse.data[0].last_name}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[0].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[0].email}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125 }}>
                                    <CardMedia
                                        sx={{ height: 125 }}
                                        image={reqresListResponse.data[1].avatar}
                                        title={reqresListResponse.data[1].first_name}
                                    />
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            {reqresListResponse.data[1].first_name} {reqresListResponse.data[1].last_name}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[1].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[1].email}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125 }}>
                                    <CardMedia
                                        sx={{ height: 125 }}
                                        image={reqresListResponse.data[2].avatar}
                                        title={reqresListResponse.data[2].first_name}
                                    />
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            {reqresListResponse.data[2].first_name} {reqresListResponse.data[2].last_name}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[2].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[2].email}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125 }}>
                                    <CardMedia
                                        sx={{ height: 125 }}
                                        image={reqresListResponse.data[3].avatar}
                                        title={reqresListResponse.data[3].first_name}
                                    />
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            {reqresListResponse.data[1].first_name} {reqresListResponse.data[3].last_name}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[3].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[3].email}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125 }}>
                                    <CardMedia
                                        sx={{ height: 125 }}
                                        image={reqresListResponse.data[4].avatar}
                                        title={reqresListResponse.data[4].first_name}
                                    />
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            {reqresListResponse.data[4].first_name} {reqresListResponse.data[4].last_name}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[4].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[4].email}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={4}>
                        <Item>
                            {reqresListResponse ?
                                <Card sx={{ minWidth: 125 }}>
                                    <CardMedia
                                        sx={{ height: 125 }}
                                        image={reqresListResponse.data[5].avatar}
                                        title={reqresListResponse.data[5].first_name}
                                    />
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            {reqresListResponse.data[5].first_name} {reqresListResponse.data[5].last_name}
                                        </Typography>
                                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                            ID: {reqresListResponse.data[5].id}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">{reqresListResponse.data[5].email}</Button>
                                    </CardActions>
                                </Card> :
                                <CircularProgress />
                            }
                        </Item>
                    </Grid>
                    <Grid item xs={8}>
                        <Pagination count={2} variant="outlined" page={page} onChange={handleChange} />
                    </Grid>
                </Grid>
            </Box>
        </>
    );
};

export default UsersList;
