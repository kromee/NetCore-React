import { Avatar, Button, Card, CardContent, CardMedia, Container, Grid, Typography } from '@material-ui/core';
import React from 'react';
import { productoArray } from '../Data/dataPrueba';
import useStyles from '../../theme/useStyles';


const Productos = (props)=>{

    const miArray = productoArray; 
    const verProducto = (id) => {
        props.history.push("/detalleProducto/" + id);
    }
    
    const classes = useStyles();
    return (
                
        <Container className={classes.containermt}>
            <Typography variant="h4" className={classes.text_title}>Productos</Typography>
            <Grid container spacing={4}>
                { miArray.map(data => (
                <Grid item lg={3} md={4} sm={6} xs={12} key={data.key}>
                    <Card>
                        <CardMedia
                        className={classes.media}
                        image="https://media.geeksforgeeks.org/wp-content/cdn-uploads/gfg_200x200-min.png"
                        title="mi producto"
                        >
                            <Avatar variant="square" className={classes.price}>
                                ${data.precio}
                            </Avatar>
                        </CardMedia>
                        <CardContent>
                            <Typography  className={classes.text_card}>
                                {data.titulo}
                            </Typography>
                            <Button
                            variant="contained"
                            color="primary"
                            fullWidth
                            onClick={() => verProducto(data.key)}
                            >
                                MAS DETALLES
                            </Button>
                        </CardContent>
                    </Card>
                </Grid>
                )) }
            </Grid>
        </Container>
    );
};

export default Productos;