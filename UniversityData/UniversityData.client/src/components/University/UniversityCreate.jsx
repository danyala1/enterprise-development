import React, { useState } from 'react';
import { TextField, Button, Container, Grid, Typography } from '@mui/material';
import api from '../../api/api';
import { useNavigate } from 'react-router-dom';
import './University.module.scss';

const UniversityCreate = () => {
  const [formData, setFormData] = useState({
    registrationNumber: '',
    name: '',
    address: '',
    institutionOwnership: '',
    buildingOwnership: '',
    rectorId: '',
  });
  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    api.post('/University', formData)
      .then(() => navigate('/universities'))
      .catch(error => console.error(error));
  };

  return (
    <Container maxWidth="sm" className="container">
      <Typography variant="h4" gutterBottom>Create New University</Typography>
      <form onSubmit={handleSubmit}>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <TextField
              label="Registration Number"
              variant="outlined"
              name="registrationNumber"
              type="number"
              value={formData.registrationNumber}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Name"
              variant="outlined"
              name="name"
              value={formData.name}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Address"
              variant="outlined"
              name="address"
              value={formData.address}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Institution Ownership"
              variant="outlined"
              name="institutionOwnership"
              value={formData.institutionOwnership}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Building Ownership"
              variant="outlined"
              name="buildingOwnership"
              value={formData.buildingOwnership}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Rector ID"
              variant="outlined"
              name="rectorId"
              type="number"
              value={formData.rectorId}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <Button type="submit" variant="contained" color="primary" fullWidth>
              Create University
            </Button>
          </Grid>
        </Grid>
      </form>
    </Container>
  );
};

export default UniversityCreate;
