import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import api from '../../api/api';
import { Card, CardContent, Typography, Button, Container, Box } from '@mui/material';

const FacultyView = () => {
  const { id } = useParams();
  const [faculty, setFaculty] = useState(null);
  const [loading, setLoading] = useState(true); 

  useEffect(() => {
    api.get(`/Faculty/${id}`)
      .then(response => {
        setFaculty(response.data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Error fetching faculty data:', error);
        setLoading(false);
      });
  }, [id]);

  return (
    <Container maxWidth="lg" sx={{ mt: 4 }}>
      {loading ? (
        <Typography variant="h6" align="center">Loading...</Typography>
      ) : (
        faculty ? (
          <Card sx={{ boxShadow: 3, borderRadius: 2 }}>
            <CardContent>
              <Typography variant="h4" gutterBottom>{faculty.name}</Typography>
              <Typography variant="h6" color="textSecondary" paragraph>
                <strong>University ID:</strong> {faculty.universityId}
              </Typography>
              <Box display="flex" justifyContent="center" sx={{ mt: 4 }}>
                <Button variant="outlined" color="primary" href="/faculties">
                  Back to Faculty List
                </Button>
              </Box>
            </CardContent>
          </Card>
        ) : (
          <Typography variant="h6" color="error" align="center">Faculty not found.</Typography>
        )
      )}
    </Container>
  );
};

export default FacultyView;
