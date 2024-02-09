import { ReactElement, FC, useState } from "react";
import { Box, Button, ButtonGroup } from '@mui/material';
import SingleResource from "../components/SingleResource";
import ResourcesList from "../components/ResourcesList";

const Resources: FC<any> = (): ReactElement => {

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
          <Button key="one" onClick={() => setPage(<SingleResource></SingleResource>)}>Show One Resource</Button>
          <Button key="two" onClick={() => setPage(<ResourcesList></ResourcesList>)}>Show All Resources</Button>
        </ButtonGroup>
      </Box>
      {page}
    </>
  );
};

export default Resources;