import React, { useState } from 'react';
import api from '../../../api/api';
import { Container, Box, Button, Typography, CircularProgress, Grid, Card, CardContent } from '@mui/material';

const AnalyticsTopDepartments = () => {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // Fetch Top Universities by Departments
  const handleTopDepartments = () => {
    setLoading(true);
    api.get('/University/top-departments')
      .then(response => {
        setData(response.data);
        setLoading(false);
        setError(null);
      })
      .catch(error => {
        setError('Error fetching top universities by departments');
        setLoading(false);
      });
  };

  return (
    <Container maxWidth="lg" sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom align="center">Top Universities by Departments</Typography>

      {/* Button to trigger the data fetch */}
      <Box display="flex" justifyContent="center" sx={{ mb: 4 }}>
        <Button variant="contained" size="large" onClick={handleTopDepartments}>
          Get Top Universities by Departments
        </Button>
      </Box>

      {/* Display loading, error, or data */}
      {loading ? (
        <Box display="flex" justifyContent="center">
          <CircularProgress />
        </Box>
      ) : error ? (
        <Typography variant="h6" color="error" align="center">{error}</Typography>
      ) : (
        <Box sx={{ mt: 4 }}>
          {data && (
            <Grid container spacing={4}>
              {data.map((university) => (
                <Grid item xs={12} sm={6} md={4} key={university.registrationNumber}>
                  <Card sx={{ boxShadow: 3, borderRadius: 2 }}>
                    <CardContent>
                      <Typography variant="h6" gutterBottom>{university.name}</Typography>
                      <Typography variant="body2" color="textSecondary" paragraph>
                        Address: {university.address}
                      </Typography>
                      <Typography variant="body2" color="textSecondary" paragraph>
                        Institution Ownership: {university.institutionOwnership}
                      </Typography>
                      <Typography variant="body2" color="textSecondary" paragraph>
                        Building Ownership: {university.buildingOwnership}
                      </Typography>
                    </CardContent>
                  </Card>
                </Grid>
              ))}
            </Grid>
          )}
        </Box>
      )}
    </Container>
  );
};

export default AnalyticsTopDepartments;
