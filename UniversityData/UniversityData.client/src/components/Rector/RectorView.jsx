import React, { useState, useEffect } from 'react';
import api from '../../api/api';
import { useParams } from 'react-router-dom';
import { Button, Typography, Card, CardContent, Container, Grid } from '@mui/material';

const RectorView = () => {
  const { id } = useParams();  // получаем id ректора из URL
  const [rector, setRector] = useState(null);

  useEffect(() => {
    api.get(`/Rector/${id}`)  // запрос на получение ректора по id
      .then(response => setRector(response.data))
      .catch(error => console.error('Error fetching rector data:', error));
  }, [id]);

  return (
    <Container maxWidth="sm" sx={{ mt: 4 }}>
      {rector ? (
        <Card elevation={3} sx={{ padding: 3 }}>
          <CardContent>
            <Typography variant="h4" gutterBottom align="center">
              {rector.fullName}
            </Typography>
            <Typography variant="h6" paragraph>
              <strong>Degree:</strong> {rector.degree}
            </Typography>
            <Typography variant="h6" paragraph>
              <strong>Title:</strong> {rector.title}
            </Typography>
            <Typography variant="h6" paragraph>
              <strong>Position:</strong> {rector.position}
            </Typography>
            <Typography variant="h6" paragraph>
              <strong>University ID:</strong> {rector.universityId}
            </Typography>

            {/* Button to go back to the list */}
            <Grid container justifyContent="center" mt={2}>
              <Grid item>
                <Button variant="outlined" href="/rectors" color="primary">
                  Back to List
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

export default RectorView;
