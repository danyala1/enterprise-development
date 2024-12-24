import React, { useState, useEffect } from 'react';
import api from '../../api/api';
import { TextField, Button, Container, Typography, Grid, Box } from '@mui/material';
import { useParams, useNavigate } from 'react-router-dom';
import './University.module.scss';

const UniversityEdit = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    registrationNumber: '',
    name: '',
    address: '',
    institutionOwnership: '',
    buildingOwnership: '',
    rectorId: '',
  });

  useEffect(() => {
    api.get(`/University/${id}`)
      .then(response => setFormData(response.data))
      .catch(error => console.error(error));
  }, [id]);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    api.put(`/University/${id}`, formData)
      .then(() => navigate('/universities'))
      .catch(error => console.error(error));
  };

  return (
    <Container maxWidth="sm" sx={{ mt: 4 }}>
      <Typography variant="h4" align="center" gutterBottom>Edit University</Typography>
      <form onSubmit={handleSubmit}>
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <TextField
              fullWidth
              label="Registration Number"
              variant="outlined"
              name="registrationNumber"
              type="number"
              value={formData.registrationNumber}
              onChange={handleChange}
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              fullWidth
              label="Name"
              variant="outlined"
              name="name"
              value={formData.name}
              onChange={handleChange}
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              fullWidth
              label="Address"
              variant="outlined"
              name="address"
              value={formData.address}
              onChange={handleChange}
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              fullWidth
              label="Institution Ownership"
              variant="outlined"
              name="institutionOwnership"
              value={formData.institutionOwnership}
              onChange={handleChange}
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              fullWidth
              label="Building Ownership"
              variant="outlined"
              name="buildingOwnership"
              value={formData.buildingOwnership}
              onChange={handleChange}
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              fullWidth
              label="Rector ID"
              variant="outlined"
              name="rectorId"
              type="number"
              value={formData.rectorId}
              onChange={handleChange}
              required
            />
          </Grid>
          <Grid item xs={12}>
            <Box display="flex" justifyContent="center">
              <Button type="submit" variant="contained" color="primary" fullWidth>
                Update University
              </Button>
            </Box>
          </Grid>
        </Grid>
      </form>
    </Container>
  );
};

export default UniversityEdit;
