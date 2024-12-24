import React, { useEffect, useState } from 'react';
import api from '../../api/api';
import { Link } from 'react-router-dom';
import { Card, CardContent, Typography, Button, Grid, Container, Box, CircularProgress } from '@mui/material';

const FacultyList = () => {
  const [faculties, setFaculties] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    api.get('/Faculty')
      .then(response => {
        setFaculties(response.data);
        setLoading(false);
        setError(null);
      })
      .catch(error => {
        setError('Error loading faculties');
        setLoading(false);
        console.error(error);
      });
  }, []);

  if (loading) {
    return (
      <Container maxWidth="sm" sx={{ mt: 4 }} align="center">
        <CircularProgress />
        <Typography variant="h6" sx={{ mt: 2 }}>Loading faculties...</Typography>
      </Container>
    );
  }

  if (error) {
    return (
      <Container maxWidth="sm" sx={{ mt: 4 }} align="center">
        <Typography variant="h6" color="error">{error}</Typography>
      </Container>
    );
  }

  return (
    <Container maxWidth="lg" sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom align="center">
        Faculty List
      </Typography>
      <Grid container spacing={3}>
        {faculties.length === 0 ? (
          <Typography variant="h6" align="center" sx={{ width: '100%' }}>
            No faculties available.
          </Typography>
        ) : (
          faculties.map((faculty) => (
            <Grid item xs={12} sm={6} md={4} key={faculty.id}>
              <Card sx={{ boxShadow: 3, borderRadius: 2 }}>
                <CardContent>
                  <Typography variant="h6" gutterBottom>{faculty.name}</Typography>
                  <Typography variant="body2" color="textSecondary" paragraph>
                    <strong>University ID:</strong> {faculty.universityId}
                  </Typography>
                  <Box display="flex" justifyContent="space-between" sx={{ mt: 2 }}>
                    <Link to={`/faculties/view/${faculty.id}`}>
                      <Button variant="outlined">View</Button>
                    </Link>
                    <Link to={`/faculties/edit/${faculty.id}`}>
                      <Button variant="outlined">Edit</Button>
                    </Link>
                    <Link to={`/faculties/delete/${faculty.id}`}>
                      <Button variant="outlined" color="error">Delete</Button>
                    </Link>
                  </Box>
                </CardContent>
              </Card>
            </Grid>
          ))
        )}
      </Grid>
      <Box display="flex" justifyContent="center" sx={{ mt: 4 }}>
        <Link to="/faculties/create">
          <Button variant="contained">Create New Faculty</Button>
        </Link>
      </Box>
    </Container>
  );
};

export default FacultyList;
