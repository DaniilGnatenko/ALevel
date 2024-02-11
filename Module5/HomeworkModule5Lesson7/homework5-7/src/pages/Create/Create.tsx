import { ReactElement, FC, useState } from "react";
import { Box, Button, Stack, TextField } from '@mui/material';
import axios from "axios";
import { IReqresPostRequest } from "../../models/reqres-post-request.model";
import { IReqresPostResponse } from "../../models/reqres-post-response.model";
import { IReqresPutResponse } from "../../models/reqres-put-response.model";

const Reqres = "https://reqres.in/"

export const Create: FC<any> = (): ReactElement => {

    const [reqresPostResponse, setReqresPostResponse] = useState<IReqresPostResponse | null>(null)

    const [reqresPutResponse, setReqresPutResponse] = useState<IReqresPutResponse | null>(null)

    const [postData, setPostData] = useState<IReqresPostRequest>(
        {
            name: "",
            job: ""
        }
    )

    const reqresCreate = () => {
        axios.post<IReqresPostRequest, IReqresPostResponse>(`${Reqres}api/users`, postData)
            .then(response => {
                console.log(response);
                console.log(postData);
                setReqresPostResponse(response);
            })
    }

    const reqresUpdate = () => {
        axios.put<IReqresPostRequest, IReqresPutResponse>(`${Reqres}api/users/2`, postData)
            .then(response => {
                console.log(response);
                console.log(postData);
                setReqresPutResponse(response);
            })
    }

    return (
        <Box component="form"
            sx={{
                '& .MuiTextField-root': { m: 1, width: '25ch' },
                flexGrow: 1,
                backgroundColor: 'whitesmoke',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center'
            }}
            noValidate
            autoComplete="off">
            <div>
                <TextField id="outlined-basic" label="Name" variant="outlined" onChange={(ev) => setPostData(prevState => {
                    return { ...prevState, name: ev.target.value }
                })} />
                <TextField id="outlined-basic" label="Job" variant="outlined" onChange={(ev) => setPostData(prevState => { return { ...prevState, job: ev.target.value } })} />
            </div>
            <Stack spacing={2} direction="row">
                <Button onClick={reqresCreate} variant="outlined">Create</Button>
                <Button onClick={reqresUpdate} variant="outlined">Update</Button>
            </Stack>
        </Box>
    );
};

export default Create;