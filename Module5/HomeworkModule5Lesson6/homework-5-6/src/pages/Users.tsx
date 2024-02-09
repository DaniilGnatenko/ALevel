import { ReactElement, FC, useState } from "react";
import {
    Box,
    Button,
    ButtonGroup
} from '@mui/material';
import UsersList from "../components/UsersList";
import SingleUser from "../components/SingleUser";

export const Users: FC<any> = (): ReactElement => {

    const [page, setPage] = useState(<></>)

    return (
        <>
            <Box
                sx={{
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                    '& > *': {
                        m: 1,
                    },
                }}
            >
                <ButtonGroup color="secondary" aria-label="Medium-sized button group">
                    <Button key="one" onClick={() => setPage(<SingleUser></SingleUser>)}>Show One User</Button>
                    <Button key="two" onClick={() => setPage(<UsersList></UsersList>)}>Show All Users</Button>
                </ButtonGroup>
            </Box>
            {page}
        </>
    );
};

export default Users;