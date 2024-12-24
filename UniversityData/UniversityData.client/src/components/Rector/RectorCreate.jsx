import React, { useState } from 'react';
import api from '../../api/api';
import { useNavigate } from 'react-router-dom';
import { Grid, TextField, Button, Container, Typography, Box } from '@mui/material';
import './Rector.module.scss';

const RectorCreate = () => {
    const [formData, setFormData] = useState({
        fullName: '',
        degree: '',
        title: '',
        position: '',
        universityId: '',
    });
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        api.post('/Rector', formData)
            .then(() => navigate('/rectors'))  
            .catch(error => console.error(error));
    };

    return (
        <Container maxWidth="sm" sx={{ mt: 4 }}>
            <Typography variant="h4" gutterBottom align="center">Create Rector</Typography>
            <Box component="form" onSubmit={handleSubmit}>
                <Grid container spacing={3}>
                    <Grid item xs={12}>
                        <TextField
                            fullWidth
                            label="Full Name"
                            name="fullName"
                            value={formData.fullName}
                            onChange={handleChange}
                            required
                            variant="outlined"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            fullWidth
                            label="Degree"
                            name="degree"
                            value={formData.degree}
                            onChange={handleChange}
                            required
                            variant="outlined"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            fullWidth
                            label="Title"
                            name="title"
                            value={formData.title}
                            onChange={handleChange}
                            required
                            variant="outlined"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            fullWidth
                            label="Position"
                            name="position"
                            value={formData.position}
                            onChange={handleChange}
                            required
                            variant="outlined"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            fullWidth
                            label="University ID"
                            name="universityId"
                            value={formData.universityId}
                            onChange={handleChange}
                            required
                            type="number"
                            variant="outlined"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <Button fullWidth variant="contained" color="primary" type="submit">
                            Create Rector
                        </Button>
                    </Grid>
                </Grid>
            </Box>
        </Container>
    );
};

export default RectorCreate;
