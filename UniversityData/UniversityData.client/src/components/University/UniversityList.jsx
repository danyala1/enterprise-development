import React, { useEffect, useState } from 'react';
import api from '../../api/api';
import { Link } from 'react-router-dom';
import { Card, CardContent, Typography, Button, Grid, Container, Box } from '@mui/material';
import './University.module.scss';

const UniversityList = () => {
  const [universities, setUniversities] = useState([]);
  
  useEffect(() => {
    api.get('/University')
      .then(response => setUniversities(response.data))
      .catch(error => console.error(error));
  }, []);

  return (
    <Container maxWidth="lg" sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom align="center">University List</Typography>
      <Grid container spacing={4}>
        {universities.map((university) => (
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
                <Box display="flex" justifyContent="space-between">
                  <Link to={`/universities/edit/${university.registrationNumber}`}>
                    <Button variant="outlined" size="small" color="primary">Edit</Button>
                  </Link>
                  <Link to={`/universities/delete/${university.registrationNumber}`}>
                    <Button variant="outlined" size="small" color="error">Delete</Button>
                  </Link>
                  <Link to={`/universities/view/${university.registrationNumber}`}>
                    <Button variant="outlined" size="small" color="info">View</Button>
                  </Link>
                </Box>
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>

      {/* Analytics Buttons */}
      <Box display="flex" justifyContent="center" sx={{ mt: 4 }}>
        <Link to="/universities/create">
          <Button variant="contained" size="large" sx={{ mr: 2 }}>Create New University</Button>
        </Link>
        <Link to="/analytics/top-departments">
          <Button variant="contained" color="success" size="large">Top Universities by Departments</Button>
        </Link>
        <Link to="/analytics/summary-ownershi">
          <Button variant="contained" color="success" size="large">University Summary by Ownership Type</Button>
        </Link>
      </Box>
    </Container>
  );
};

export default UniversityList;
