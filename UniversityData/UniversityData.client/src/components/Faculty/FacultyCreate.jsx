import React, { useState } from 'react';
import { TextField, Button, Container, Grid, Typography } from '@mui/material';
import api from '../../api/api';
import { useNavigate } from 'react-router-dom';
import './Faculty.module.scss';

const FacultyCreate = () => {
  const [formData, setFormData] = useState({
    name: '',
    universityId: '',
  });
  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    api.post('/Faculty', formData)
      .then(() => navigate('/faculties'))
      .catch(error => console.error(error));
  };

  return (
    <Container maxWidth="sm" className="container">
      <Typography variant="h4" gutterBottom>Create New Faculty</Typography>
      <form onSubmit={handleSubmit}>
        <Grid container spacing={2}>
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
              label="University ID"
              variant="outlined"
              name="universityId"
              type="number"
              value={formData.universityId}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <Button type="submit" variant="contained" color="primary" fullWidth>
              Create Faculty
            </Button>
          </Grid>
        </Grid>
      </form>
    </Container>
  );
};

export default FacultyCreate;
