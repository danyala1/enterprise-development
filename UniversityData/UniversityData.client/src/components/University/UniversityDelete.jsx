import React, { useState, useEffect } from 'react';
import api from '../../api/api';
import { useParams, useNavigate } from 'react-router-dom';
import { Button, Container, Typography, Box, CircularProgress } from '@mui/material';

const UniversityDelete = () => {
  const { id } = useParams(); 
  const [university, setUniversity] = useState(null);
  const navigate = useNavigate(); 

  useEffect(() => {
    if (id) {
      api.get(`/University/${id}`)
        .then(response => setUniversity(response.data))
        .catch(error => console.error(error));
    }
  }, [id]);

  const handleDelete = () => {
    api.delete(`/University/${id}`)
      .then(() => navigate('/universities'))
      .catch(error => console.error(error));
  };

  return (
    <Container maxWidth="sm" sx={{ mt: 4 }}>
      {university ? (
        <Box sx={{ textAlign: 'center' }}>
          <Typography variant="h5" gutterBottom>
            Are you sure you want to delete this university?
          </Typography>
          <Typography variant="h6" color="textSecondary" gutterBottom>
            {university.name}
          </Typography>
          <Typography variant="body1" color="textSecondary" paragraph>
            {university.address}
          </Typography>
          <Box sx={{ display: 'flex', justifyContent: 'center', gap: 2 }}>
            <Button
              variant="contained"
              color="error"
              onClick={handleDelete}
              size="large"
            >
              Delete
            </Button>
            <Button
              variant="outlined"
              onClick={() => navigate('/universities')}
              size="large"
            >
              Cancel
            </Button>
          </Box>
        </Box>
      ) : (
        <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '60vh' }}>
          <CircularProgress />
        </Box>
      )}
    </Container>
  );
};

export default UniversityDelete;
