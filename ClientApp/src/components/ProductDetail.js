import React, { Component } from 'react';
import axios from 'axios';
import './ProductDetail.css';

export class ProductDetail extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: [],
            obj: []
        };
        this.addToCart = this.addToCart.bind(this);
    }

    addToCart(item) {
        if (localStorage.getItem("id_token")!=null) { // if loggin
            if (localStorage.getItem("cart") != "[]") {
                var myJsonObject = (item); 
                myJsonObject.quantity = 1; 
                myJsonObject = JSON.stringify(myJsonObject); //change back to string
                var items = localStorage.getItem("cart").slice(0, -1).concat(',' + myJsonObject) + "]"; // set as array string
                localStorage.setItem("cart", items); // add array cart to localstorage
            }
            else {
                var myJsonObject = (item); //change to obj
                myJsonObject.quantity = 1; //add quantity
                myJsonObject = "[" + JSON.stringify(myJsonObject) + "]"; //change back to string
                localStorage.setItem("cart", myJsonObject);
            }
        }
    }

    getProductToAddCart() {
        const id = localStorage.getItem("PID");
        fetch("/api/Home/Product/" + id)
            .then(res => res.json())
            .then(result => {
                this.setState({
                    obj: JSON.parse('[' + JSON.stringify(result) + ']')
                })
            })
    }

    componentDidMount() {
        const id = localStorage.getItem("PID");
        fetch("/api/Home/Products/" + id)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: JSON.parse('[' + JSON.stringify(result) + ']')
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
        );
        this.getProductToAddCart();
        
    }

    render() {
        const { error, isLoaded, items, obj } = this.state;           
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>;
        } else {
            return (
                <div className="container">
                    <div className="container">
                        {items.map(item => (
                            <h1>{item.name}</h1>

                        ))}
                        <div id="myCarousel" className="carousel slide" data-ride="carousel">
                            {/* Indicators */}
                            <ol className="carousel-indicators">
                                <li data-target="#myCarousel" data-slide-to={0} className="active" />
                                <li data-target="#myCarousel" data-slide-to={1} />
                                <li data-target="#myCarousel" data-slide-to={2} />
                            </ol>
                            {/* Wrapper for slides */}
                            {items.map(item => (
                                <div className="carousel-inner">
                                    <div className="item active">
                                        <img src={item.imgUrl1} style={{ width: '100%', maxHeight: '400px', objectFit: "cover" }} />
                                    </div>
                                    <div className="item">
                                        <img src={item.imgUrl2} style={{ width: '100%', maxHeight: '400px', objectFit: "cover" }} />
                                    </div>
                                    <div className="item">
                                        <img src={item.imgUrl3} style={{ width: '100%', maxHeight: '400px', objectFit: "cover" }} />
                                    </div>
                                </div>
                            ))}
                            {/* Left and right controls */}
                            <a className="left carousel-control" href="#myCarousel" data-slide="prev">
                                <span className="glyphicon glyphicon-chevron-left" />
                                <span className="sr-only">Previous</span>
                            </a>
                            <a className="right carousel-control" href="#myCarousel" data-slide="next">
                                <span className="glyphicon glyphicon-chevron-right" />
                                <span className="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
                    {obj.map(item => (
                        <div className="text-center">
                            <button onClick={() => this.addToCart(item)} type="button" className="btn btn-warning">Add To Cart</button>
                        </div>
                    ))}
                    <div className="container">
                        {items.map(item => (
                            <div className="panel panel-default">
                                <div className="panel-heading"><b>Introduction: {item.name}</b></div>
                                <div className="panel-body"><b>Powerhouse performance
                                Ultimate mobile performance:</b> The most powerful XPS laptop we’ve ever built 
                                    includes 9th gen Intel Core i7-9750H processor, delivering the ultimate 
                                    power for gamers and creators. Maximum memory and storage: Supports 16GB of
                                    memory with a bandwidth of 2666MHz, 1.2 times the speed of 2133MHz. <br/><br/><b>Faster
                                    memory</b> means you get to the content that you need quicker. Storage 1TB M.2 PCIe NVMe SSD,
                                    available in faster PCIe versions, provide plenty of storage room and high-performance
                                    responsiveness to access and run your applications quickly. The XPS 15 boots and resumes
                                    in seconds with a solid state drive, so you can do more without waiting.</div>
                            </div>
                        ))}
                    </div>

                    <table className="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>Features</th>
                                <th>Specs</th>
                            </tr>
                        </thead>
                        <tbody>
                            {items.map(item => (<tr><td>Operating System</td><td>{item.operatingSystem}</td></tr>))}
                            {items.map(item => (<tr><td>Manufacturer</td><td>{item.manufacturer}</td></tr>))}
                            {items.map(item => (<tr><td>Cpu</td><td>{item.cpu}</td></tr>))}
                            {items.map(item => (<tr><td>Cup Speed</td><td>{item.cpuSpeed}</td></tr>))}
                            {items.map(item => (<tr><td>Number of cores</td><td>{item.numCores}</td></tr>))}
                            {items.map(item => (<tr><td>Cache Type</td><td>{item.cacheType}</td></tr>))}
                            {items.map(item => (<tr><td>Cache Size</td><td>{item.cacheSize}</td></tr>))}
                            {items.map(item => (<tr><td>Chipset Type</td><td>{item.chipsetType}</td></tr>))}
                            {items.map(item => (<tr><td>Features</td><td>{item.features}</td></tr>))}
                            {items.map(item => (<tr><td>Ram Type</td><td>{item.ramType}</td></tr>))}
                            {items.map(item => (<tr><td>Ram Speed</td><td>{item.ramSpeed}</td></tr>))}
                            {items.map(item => (<tr><td>Ram Size</td><td>{item.ramSize}</td></tr>))}
                            {items.map(item => (<tr><td>Display Technology</td><td>{item.displayTech}</td></tr>))}
                            {items.map(item => (<tr><td>Display Resolution</td><td>{item.displayResolution}</td></tr>))}
                            {items.map(item => (<tr><td>Display Size</td><td>{item.displaySize}</td></tr>))}
                            {items.map(item => (<tr><td>Display Type</td><td>{item.displayType}</td></tr>))}
                            {items.map(item => (<tr><td>Graphic Name</td><td>{item.graphicName}</td></tr>))}
                            {items.map(item => (<tr><td>Graphic Size</td><td>{item.graphicSize}</td></tr>))}
                            {items.map(item => (<tr><td>Webcam</td><td>{item.webcam}</td></tr>))}
                            {items.map(item => (<tr><td>Sound</td><td>{item.sound}</td></tr>))}
                            {items.map(item => (<tr><td>Audio Codec</td><td>{item.audioCodec}</td></tr>))}
                            {items.map(item => (<tr><td>Hard Drive Type</td><td>{item.hardDriveType}</td></tr>))}
                            {items.map(item => (<tr><td>Hard Drive Size</td><td>{item.hardDriveSize}</td></tr>))}
                            {items.map(item => (<tr><td>Input Type</td><td>{item.inputType}</td></tr>))}
                            {items.map(item => (<tr><td>Wireless Protocol</td><td>{item.wirelessProtocol}</td></tr>))}
                            {items.map(item => (<tr><td>Wireless Controller</td><td>{item.wirelessController}</td></tr>))}
                            {items.map(item => (<tr><td>Bluetooth</td><td>{item.bluetooth}</td></tr>))}
                            {items.map(item => (<tr><td>Card Reader Type</td><td>{item.cardReaderType}</td></tr>))}
                            {items.map(item => (<tr><td>Card Reader Support</td><td>{item.cardReaderSupport}</td></tr>))}
                            {items.map(item => (<tr><td>Battery Size</td><td>{item.batterySize}</td></tr>))}
                            {items.map(item => (<tr><td>Battery Cells</td><td>{item.baterryCells}</td></tr>))}
                            {items.map(item => (<tr><td>Dimensions</td><td>{item.dimensions}</td></tr>))}
                            {items.map(item => (<tr><td>Mainboard</td><td>{item.mainboard}</td></tr>))}
                            {items.map(item => (<tr><td>Weight</td><td>{item.weight}</td></tr>))}
                            {items.map(item => (<tr><td>Backlight</td><td>{item.backlight}</td></tr>))}
                        </tbody>
                    </table>    
               </div>
            );
        }
    }
}