import React, { useState, useEffect } from 'react';
import api from '../../api/api';
import { useParams, useNavigate } from 'react-router-dom';
import { Button, Typography, Container, Card, CardContent, Grid } from '@mui/material';

const RectorDelete = () => {
  const { id } = useParams();
  const [rector, setRector] = useState(null); 
  const navigate = useNavigate(); 

  useEffect(() => {
    if (id) {
      api.get(`/Rector/${id}`)
        .then(response => setRector(response.data))
        .catch(error => console.error('Error fetching rector data:', error));
    }
  }, [id]);

  const handleDelete = () => {
    if (id) {
      const data = { id: Number(id) };

      api.delete('/Rector', { data })
        .then(() => navigate('/rectors'))
        .catch(error => console.error('Error deleting rector:', error));
    }
  };

  return (
    <Container maxWidth="sm" sx={{ mt: 4 }}>
      {rector ? (
        <Card elevation={3} sx={{ padding: 3 }}>
          <CardContent>
            <Typography variant="h4" align="center" gutterBottom>
              Are you sure you want to delete this rector?
            </Typography>
            <Typography variant="h6" align="center" paragraph>
              <strong>Full Name:</strong> {rector.fullName}
            </Typography>

            {/* Кнопки для удаления и отмены */}
            <Grid container justifyContent="center" spacing={2}>
              <Grid item>
                <Button onClick={handleDelete} color="error" variant="contained">
                  Delete
                </Button>
              </Grid>
              <Grid item>
                <Button onClick={() => navigate('/rectors')} variant="outlined">
                  Cancel
                </Button>
              </Grid>
            </Grid>
          </CardContent>
        </Card>
      ) : (
        <Typography variant="h6" align="center">Loading...</Typography>
      )}
    </Container>
  );
};

export default RectorDelete;
