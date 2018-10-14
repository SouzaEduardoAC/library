import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import Button from './RemoveButton';

const styles = {
  card: {
    marginLeft: 100,
    marginRight: 100,
    marginTop: 10,
    marginBottom: 20,
    minWidth: 275,
  },
  bullet: {
    display: 'inline-block',
    margin: '0 2px',
    transform: 'scale(0.8)',
  },
  title: {
    fontSize: 14,
  },
  pos: {
    marginBottom: 12,
  },
};

function SimpleCard(props) {
  const { classes } = props;

  return (
    <Card 
      className={classes.card} 
      itemID={ props.id } 
      >
      <CardContent>
        <Typography variant="h5" component="h2">
          { props.title }
        </Typography>
        <Typography className={classes.pos} color="textSecondary">
          { props.author }
        </Typography>
        <Typography component="p">
          { props.releaseDate }
        </Typography>
      </CardContent>
      <Button id = {props.id}/>
    </Card>
  );
}

SimpleCard.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(SimpleCard);