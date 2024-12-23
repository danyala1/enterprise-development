import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import api from '../../api/api';
import { Button, TextField, Snackbar, Alert } from '@mui/material';
import './EditRector.scss';

const EditRector = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    fullName: '',
    degree: '',
    title: '',
    position: '',
    universityId: '', 
  });
  const [notification, setNotification] = useState({ open: false, message: '', severity: '' });

  useEffect(() => {
    const fetchRector = async () => {
      try {
        const response = await api.get(`/Rector/${id}`);
        setFormData(response.data);
      } catch (error) {
        showNotification('Failed to fetch rector data.', 'error');
      }
    };

    fetchRector();
  }, [id]);

  

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put(`/Rector/${id}`, formData);
      showNotification('Rector updated successfully!', 'success');
      setTimeout(() => navigate('/'), 3000);
    } catch (error) {
      showNotification('Failed to update rector.', 'error');
    }
  };

  const showNotification = (message, severity) => {
    setNotification({ open: true, message, severity });
  };

  const closeNotification = () => {
    setNotification({ ...notification, open: false });
  };

  return (
    <form onSubmit={handleSubmit} className="edit-rector">
      <h1>Edit Rector</h1>
      <TextField name="fullName" label="Full Name" value={formData.fullName} onChange={handleChange} required />
      <TextField name="degree" label="Degree" value={formData.degree} onChange={handleChange} required />
      <TextField name="title" label="Title" value={formData.title} onChange={handleChange} required />
      <TextField name="position" label="Position" value={formData.position} onChange={handleChange} required />
      <TextField name="universityId" label="University ID" value={formData.universityId} onChange={handleChange} required />
      
      <Button type="submit" variant="contained" color="primary">Save</Button>

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

export default EditRector;
