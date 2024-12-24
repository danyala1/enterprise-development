import React, { useState, useEffect } from 'react';
import api from '../../api/api';
import { TextField, Button, Container, Grid, Typography } from '@mui/material';
import { useParams, useNavigate } from 'react-router-dom';
import './Rector.module.scss';

const RectorEdit = () => {
  const { id } = useParams();
  const navigate = useNavigate();  
  const [formData, setFormData] = useState({
    fullName: '',
    degree: '',
    title: '',
    position: '',
    universityId: '',
  });

  useEffect(() => {
    api.get(`/Rector/${id}`)
      .then(response => setFormData(response.data))
      .catch(error => console.error('Error fetching rector data:', error));
  }, [id]);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    api.put(`/Rector/${id}`, formData)
      .then(() => navigate('/rectors'))
      .catch(error => console.error('Error updating rector:', error));
  };

  return (
    <Container maxWidth="sm" className="container">
      <Typography variant="h4" gutterBottom>Edit Rector</Typography>
      <form onSubmit={handleSubmit}>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <TextField
              label="Full Name"
              variant="outlined"
              name="fullName"
              value={formData.fullName}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Degree"
              variant="outlined"
              name="degree"
              value={formData.degree}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Title"
              variant="outlined"
              name="title"
              value={formData.title}
              onChange={handleChange}
              fullWidth
              required
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Position"
              variant="outlined"
              name="position"
              value={formData.position}
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
              Update Rector
            </Button>
          </Grid>
        </Grid>
      </form>
    </Container>
  );
};

export default RectorEdit;
