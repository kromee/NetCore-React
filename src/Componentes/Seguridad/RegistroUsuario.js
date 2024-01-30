import { Avatar, Button, Card, Container, Grid, Icon, TextField, Typography } from "@material-ui/core";
import React, { useState } from "react";
import useStyles from '../../theme/useStyles';

import { Link } from "react-router-dom";

const clearUsuario ={
    nombre:'',
    apellidos:'',
    email:'',
    password:''
}

const RegistrarUsuario =()=>{

    const [usuario, setUsuario]= useState({
        nombre:'',
        apellidos:'',
        email:'',
        password:''

    });


const handleChange = (e)=>{
    const {name, value}= e.target;
    setUsuario(prev=>({
        ...prev,
        [name]:value
    }))
}

const guardarUsuario=()=>{
    console.log('Mi usiario es', usuario);
    setUsuario(clearUsuario);
}


    const classes = useStyles();
    return (
        <Container className={classes.containermt}>
            <Grid container justifyContent="center">
                <Grid item lg={6} md={8}>
                   <Card className={classes.card}>
                    <Avatar className={classes.avatar}>
                        <Icon className={classes.icon}>person-add</Icon>
                    </Avatar>
                    <Typography variant="h5" color="primary">Registro de usuario</Typography>
                   </Card>
                   <form className={classes.form} onSubmit={(e)=>e.preventDefault()}>
                        <Grid container spacing={2}>
                            <Grid item md={6} xs={12} className={classes.gridmb}>
                                    <TextField
                                        label="Nombre"
                                        variant="outlined"
                                        name='nombre'
                                        value={usuario.nombre}
                                        onChange={handleChange}
                                        fullWidth
                                        />
                    
                            </Grid>
                            <Grid item md={6} xs={12} className={classes.gridmb}>
                                    <TextField
                                        label="Apellidos"
                                        variant="outlined"
                                        name='apellidos'
                                        value={usuario.apellidos}
                                        onChange={handleChange}
                                        fullWidth/>
                                
                            </Grid>
                            <Grid item md={12} xs={12} className={classes.gridmb}>
                                    <TextField
                                        label="Email"
                                        variant="outlined"
                                        fullWidth
                                        name='email'
                                        value={usuario.email}
                                        onChange={handleChange}
                                        type="email" />
                                
                            </Grid>
                            <Grid item md={12} xs={12} className={classes.gridmb}>
                                    <TextField
                                        label="Password"
                                        variant="outlined"
                                        fullWidth
                                        type="password"
                                        name='password'
                                        value={usuario.password}
                                        onChange={handleChange}
                                        />
                                
                            </Grid>
                            <Grid item md={12} xs={12} className={classes.gridmb}>
                                  <Button 
                                  variant="contained"
                                  fullWidth
                                  color="primary"
                                  onClick={guardarUsuario}
                                  > 
                                 
                                  Registrar
                                  </Button>
                            </Grid>
                        </Grid>
                        <Link 
                        to="/login"
                        variant="body1"     className={classes.link}>
                        
                            ¿Ya tienes una cuenta?, logeate
                        </Link>
                    </form>


                </Grid>

            </Grid>
        </Container>
    );
};

export default RegistrarUsuario;