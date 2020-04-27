import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import './Home_products.css';
import NotificationAlert from 'react-notification-alert';

var success = { place: 'tl', message: (<div>Item added successful</div>), type: "success", icon: "now-ui-icons ui-1_bell-53", autoDismiss: 2 };
var unsuccess = { place: 'tl', message: (<div>Please login to start shopping</div>), type: "danger", icon: "now-ui-icons ui-1_bell-53", autoDismiss: 2 };


export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: [],
            visible: false
        };
    }

    onShowAlert = () => {
        this.setState({ visible: true }, () => {
            window.setTimeout(() => {
                this.setState({ visible: false })
            }, 2000)
        });
    }
    noti() {
        if (localStorage.getItem("id_token") !== null)
            this.refs.notify.notificationAlert(success);
        else
            this.refs.notify.notificationAlert(unsuccess)
    }

    componentDidMount() {
        fetch("/api/Home/Products")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                },
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            )
    }

    render() {
        const { error, isLoaded, items } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>;
        } else {
            return (
                <Fragment>
                    <div className="page-header" style={{ marginLeft: '30px' }}><h1>OUR PRODUCTS</h1></div>
                    <NotificationAlert ref="notify" />
                <div className="row">                 
                    {items.map(item => (
                        <div id="card-wrapper" className="cwrapper">
                            
                            <div id="cproduct-img" className="cproduct-img">
                                <Link to='/productdetail' onClick={()=>localStorage.setItem("PID", item.productId)}>
                                    <img id="thumbnail" src={item.productImageUrl} />
                                </Link>
                            </div>
                            

                            <div id="product-info" className="product-info">
                                <div id="product-text" className="product-text">
                                    <Link to='/productdetail' onClick={() => localStorage.setItem("PID", item.productId)}>
                                        <h1><b>{item.productName}</b></h1>
                                    </Link>
                                    <h2>imported by knn inc</h2>
                                    <p>{item.productInformation}</p>
                                </div>
                                <div className="product-price-btn">
                                    <p><span id="price" >${item.productPrice}</span></p>
                                    <button onClick={() => { this.props.addToCart(JSON.stringify(item)); this.noti(); }} type="button">Add to cart</button>
                                </div>
                            </div>

                        </div>

                    ))}
                    </div>
                    </Fragment>
            );
        }
    }
}