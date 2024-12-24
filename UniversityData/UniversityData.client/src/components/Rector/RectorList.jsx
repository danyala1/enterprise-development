import React, { useEffect, useState } from 'react';
import api from '../../api/api';
import { Link } from 'react-router-dom';
import { Card, CardContent, Typography, Button, Grid, Container } from '@mui/material';
import './Rector.module.scss';

const RectorList = () => {
  const [rectors, setRectors] = useState([]);

  useEffect(() => {
    api.get('/Rector')
      .then(response => setRectors(response.data))
      .catch(error => console.error(error));
  }, []);

  return (
    <Container maxWidth="lg" className="rector-container">
      <Typography variant="h4" gutterBottom align="center">
        Rector List
      </Typography>
      
      <Grid container spacing={3}>
        {rectors.map((rector) => (
          <Grid item xs={12} sm={6} md={4} key={rector.id}>
            <Card elevation={3} className="rector-card">
              <CardContent>
                <Typography variant="h6" gutterBottom>
                  {rector.fullName}
                </Typography>
                <Typography variant="body2" paragraph>
                  <strong>Degree:</strong> {rector.degree}
                </Typography>
                <Typography variant="body2" paragraph>
                  <strong>Title:</strong> {rector.title}
                </Typography>
                <Typography variant="body2" paragraph>
                  <strong>Position:</strong> {rector.position}
                </Typography>

                <Grid container spacing={1}>
                  {/* Edit button */}
                  <Grid item>
                    <Link to={`/rectors/edit/${rector.id}`}>
                      <Button variant="outlined" fullWidth>
                        Edit
                      </Button>
                    </Link>
                  </Grid>
                  
                  {/* Delete button */}
                  <Grid item>
                    <Link to={`/rectors/delete/${rector.id}`}>
                      <Button variant="outlined" color="error" fullWidth>
                        Delete
                      </Button>
                    </Link>
                  </Grid>
                  
                  {/* View button */}
                  <Grid item>
                    <Link to={`/rectors/view/${rector.id}`}>
                      <Button variant="outlined" color="primary" fullWidth>
                        View
                      </Button>
                    </Link>
                  </Grid>
                </Grid>
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>
      
      {/* Create New Rector Button */}
      <Grid container justifyContent="center" spacing={2} mt={3}>
        <Grid item>
          <Link to="/rectors/create">
            <Button variant="contained" color="primary">
              Create New Rector
            </Button>
          </Link>
        </Grid>
      </Grid>
    </Container>
  );
};

export default RectorList;
