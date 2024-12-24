import React, { useState, useEffect } from 'react';
import api from '../../api/api';
import { useParams, useNavigate } from 'react-router-dom';
import { Button, Typography, Container, Box, CircularProgress } from '@mui/material';

const FacultyDelete = () => {
  const { id } = useParams();
  const [faculty, setFaculty] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null); 
  const navigate = useNavigate();

  useEffect(() => {
    api.get(`/Faculty/${id}`)
      .then(response => {
        setFaculty(response.data);
        setLoading(false);
      })
      .catch(error => {
        setError('Error loading faculty details');
        setLoading(false);
        console.error(error);
      });
  }, [id]);

  const handleDelete = () => {
    api.delete(`/Faculty/${id}`)
      .then(() => {
        navigate('/faculties');
      })
      .catch(error => {
        setError('Error deleting faculty');
        console.error(error);
      });
  };

  return (
    <Container maxWidth="sm" sx={{ mt: 4 }} align="center">
      {loading ? (
        <Box>
          <CircularProgress />
          <Typography variant="h6" sx={{ mt: 2 }}>Loading faculty data...</Typography>
        </Box>
      ) : error ? (
        <Typography variant="h6" color="error">{error}</Typography>
      ) : faculty ? (
        <Box>
          <Typography variant="h4" gutterBottom>
            Are you sure you want to delete this faculty?
          </Typography>
          <Typography variant="h6" paragraph>
            <strong>Faculty Name:</strong> {faculty.name}
          </Typography>
          <Typography variant="body1" paragraph>
            <strong>University ID:</strong> {faculty.universityId}
          </Typography>
          <Box display="flex" justifyContent="center" sx={{ mt: 2 }}>
            <Button onClick={handleDelete} color="error" variant="contained">
              Delete Faculty
            </Button>
          </Box>
        </Box>
      ) : (
        <Typography variant="h6" color="error">Faculty not found.</Typography>
      )}
    </Container>
  );
};

export default FacultyDelete;
