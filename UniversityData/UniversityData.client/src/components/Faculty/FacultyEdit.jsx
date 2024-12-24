import React, { useState, useEffect } from 'react';
import api from '../../api/api';
import { TextField, Button, Container } from '@mui/material';
import { useParams, useNavigate } from 'react-router-dom';
import './Faculty.module.scss';

const FacultyEdit = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    name: '',
    universityId: '',
  });

  useEffect(() => {
    api.get(`/Faculty/${id}`)
      .then(response => setFormData(response.data))
      .catch(error => console.error(error));
  }, [id]);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    api.put(`/Faculty/${id}`, formData)
      .then(() => navigate('/faculties'))
      .catch(error => console.error(error));
  };

  return (
    <Container>
      <h1>Edit Faculty</h1>
      <form onSubmit={handleSubmit}>
        <TextField
          label="Name"
          variant="outlined"
          name="name"
          value={formData.name}
          onChange={handleChange}
          fullWidth
          required
        />
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
        <Button type="submit" variant="contained" color="primary">Update Faculty</Button>
      </form>
    </Container>
  );
};

export default FacultyEdit;
