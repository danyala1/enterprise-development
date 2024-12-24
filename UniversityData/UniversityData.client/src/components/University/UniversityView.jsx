import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import api from '../../api/api';
import { Card, CardContent, Typography, Button, Container, Box } from '@mui/material';

const UniversityView = () => {
  const { id } = useParams(); 
  const [university, setUniversity] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    api.get(`/University/${id}`)
      .then(response => {
        setUniversity(response.data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Error fetching university data:', error);
        setLoading(false);
      });
  }, [id]);

  return (
    <Container maxWidth="lg" sx={{ mt: 4 }}>
      {loading ? (
        <Typography variant="h6" align="center">Loading...</Typography>
      ) : (
        university ? (
          <Card sx={{ boxShadow: 3, borderRadius: 2 }}>
            <CardContent>
              <Typography variant="h4" gutterBottom>{university.name}</Typography>
              <Typography variant="h6" color="textSecondary" paragraph>
                <strong>Registration Number:</strong> {university.registrationNumber}
              </Typography>
              <Typography variant="h6" color="textSecondary" paragraph>
                <strong>Address:</strong> {university.address}
              </Typography>
              <Typography variant="h6" color="textSecondary" paragraph>
                <strong>Institution Ownership:</strong> {university.institutionOwnership}
              </Typography>
              <Typography variant="h6" color="textSecondary" paragraph>
                <strong>Building Ownership:</strong> {university.buildingOwnership}
              </Typography>
              <Typography variant="h6" color="textSecondary" paragraph>
                <strong>Rector ID:</strong> {university.rectorId}
              </Typography>
              <Box display="flex" justifyContent="center" sx={{ mt: 4 }}>
                <Button variant="outlined" color="primary" href="/universities">
                  Back to University List
                </Button>
              </Box>
            </CardContent>
          </Card>
        ) : (
          <Typography variant="h6" color="error" align="center">University not found.</Typography>
        )
      )}
    </Container>
  );
};

export default UniversityView;
