import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../../api/api';
import { Button, TextField, Snackbar, Alert } from '@mui/material';
import './CreateRector.scss';

const CreateRector = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    fullName: '',
    degree: '',
    title: '',
    position: '',
    universityId: 0,
  });
  const [notification, setNotification] = useState({ open: false, message: '', severity: '' });

  const handleChange = (e) => {
    const { name, value } = e.target;
    const parsedValue = name === 'universityId' ? parseInt(value, 10) || 0 : value;

    setFormData({ ...formData, [name]: parsedValue });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (formData.universityId <= 0) {
      showNotification('University ID must be a positive number!', 'error');
      return;
    }

    try {
      const payload = { ...formData, universityId: Number(formData.universityId) };
      await api.post('/Rector', payload);
      showNotification('Rector added successfully!', 'success');
      setTimeout(() => navigate('/'), 3000);
    } catch (error) {
      showNotification('Failed to add rector.', 'error');
    }
  };

  const showNotification = (message, severity) => {
    setNotification({ open: true, message, severity });
  };

  const closeNotification = () => {
    setNotification({ ...notification, open: false });
  };

  return (
    <form onSubmit={handleSubmit} className="create-rector">
      <h1>Create Rector</h1>
      <TextField
        name="fullName"
        label="Full Name"
        value={formData.fullName}
        onChange={handleChange}
        required
      />
      <TextField
        name="degree"
        label="Degree"
        value={formData.degree}
        onChange={handleChange}
        required
      />
      <TextField
        name="title"
        label="Title"
        value={formData.title}
        onChange={handleChange}
        required
      />
      <TextField
        name="position"
        label="Position"
        value={formData.position}
        onChange={handleChange}
        required
      />
      <TextField
        name="universityId"
        label="University ID"
        value={formData.universityId}
        onChange={handleChange}
        required
        type="number"
      />
      <Button type="submit" variant="contained" color="primary">
        Save
      </Button>

      <Snackbar
        open={notification.open}
        autoHideDuration={3000}
        onClose={closeNotification}
        anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
      >
        <Alert onClose={closeNotification} severity={notification.severity} variant="filled">
          {notification.message}
        </Alert>
      </Snackbar>
    </form>
  );
};

export default CreateRector;
