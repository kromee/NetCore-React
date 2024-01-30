import { Avatar, Card, Container, Grid, Icon, TextField, Typography, Button } from "@material-ui/core";
import React from "react";
import useStyles from '../../theme/useStyles';

import { Link } from "react-router-dom";




const Login = () => {
    const classes = useStyles();
    return (
    <div>
       <Container className={classes.containermt}>
        <Grid  container justifyContent="center">
            <Grid  item lg={5} md={6}>
                <Card id="cardlogin" aling="center" className= {classes.card}>
                    <Avatar className= {classes.avatar}>
                        <Icon className= {classes.icon}>person</Icon>
                    </Avatar>
                    <Typography variant="h5" color="primay" className={classes.typography}>
                        Ingrese su usuario:
                    </Typography>
                    <form className={classes.form}>
                    <Grid container spacing={2} className={classes.gridmb}>
                        <Grid item xs={12}>
                            <TextField label="Email" variant="outlined"  fullWidth type="email"/>
                        </Grid>
                        <Grid item xs={12} className={classes.gridmb}>
                            <TextField label="Password" variant="outlined"  fullWidth type="password"/>
                        </Grid>
                        <Grid item xs={12} className={classes.gridmb}>
                            <Button variant="contained"
                            fullWidth
                            color="primary"
                            >Ingresar</Button>
                        </Grid>
                    </Grid>
                    <Link to="/registrar" variant="body1" className={classes.link}>¿No tienes cuenta?, Registrate</Link>
                    </form>
              
                </Card>

            </Grid>
        </Grid>
       </Container>
    </div>
    )
}

export default Login;