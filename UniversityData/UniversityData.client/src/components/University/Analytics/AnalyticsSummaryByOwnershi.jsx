import React, { useState } from 'react';
import api from '../../../api/api';
import { Container, Box, Button, Typography, CircularProgress, Grid, Card, CardContent } from '@mui/material';

const AnalyticsSummaryByOwnership = () => {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // Fetch University Summary by Ownership Type
  const handleSummaryByOwnership = () => {
    setLoading(true);
    api.get('/api/University/summary')
      .then(response => {
        setData(response.data);  // Response should be an array
        setLoading(false);
        setError(null);
      })
      .catch(error => {
        setError('Error fetching university summary by ownership type');
        setLoading(false);
      });
  };

  return (
    <Container maxWidth="lg" sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom align="center">University Summary by Ownership Type</Typography>

      {/* Button to trigger the data fetch */}
      <Box display="flex" justifyContent="center" sx={{ mb: 4 }}>
        <Button variant="contained" size="large" onClick={handleSummaryByOwnership}>
          Get University Summary by Ownership Type
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
          {data && data.length > 0 ? (
            <Grid container spacing={4}>
              {data.map((summary, index) => (
                <Grid item xs={12} sm={6} md={4} key={index}>
                  <Card sx={{ boxShadow: 3, borderRadius: 2 }}>
                    <CardContent>
                      <Typography variant="h6" gutterBottom>{summary.ownershipType}</Typography>
                      <Typography variant="body2" color="textSecondary" paragraph>
                        Faculty Count: {summary.facultyCount}
                      </Typography>
                      <Typography variant="body2" color="textSecondary" paragraph>
                        Department Count: {summary.departmentCount}
                      </Typography>
                      <Typography variant="body2" color="textSecondary" paragraph>
                        Specialty Count: {summary.specialtyCount}
                      </Typography>
                    </CardContent>
                  </Card>
                </Grid>
              ))}
            </Grid>
          ) : (
            <Typography variant="h6" align="center">No summary data available</Typography>
          )}
        </Box>
      )}
    </Container>
  );
};

export default AnalyticsSummaryByOwnership;
