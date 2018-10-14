import React, { Component } from 'react';
import TopBar from './components/TopBar';
import BookCard from './components/BookCard';
import BookForm from './components/BookForm';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      bookText: '',
      books: [],
    }
  }

  componentDidMount() {
    fetch('http://localhost:8080/api/books')
      .then(res => res.json())
      .then(json => {
        this.setState({ books: json })
      })
  }

  render() {
    let books = this.state.books.map((val, key) => {
      return <BookCard 
        key={key} 
        id={val.id}
        title={val.title} 
        author={val.author} 
        releaseDate={val.releaseDate}
        />
    })

    return (
      <div className="container">
        <TopBar />
        <BookForm />
        { books }
      </div>
    );
  }
}

export default App;
