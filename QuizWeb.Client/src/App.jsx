import { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { themes: [], loading: true };
    }

    componentDidMount() {
        this.themeData();
    }

    static renderThemesTable(themes) {
        return (
            <table className='table table-striped' aria-labelledby='tabelLabel'>
                <thead>
                    <tr>
                        <th>Theme Name</th>
                        <th>Created Date</th>
                        <th>Modifier Date</th>
                    </tr>
                </thead>
                <tbody>
                    {themes.map((theme) => (
                        <tr key={theme.id}>
                            <td>{theme.themeName}</td>
                            <td>{theme.createDate}</td>
                            <td>{theme.modifierDate}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading ? (
            <p>
                <em>
                    Loading... Please refresh once the ASP.NET backend has
                    started. See{' '}
                    <a href='https://aka.ms/jspsintegrationreact'>
                        https://aka.ms/jspsintegrationreact
                    </a>{' '}
                    for more details.
                </em>
            </p>
        ) : (
            App.renderThemesTable(this.state.themes)
        );

        return (
            <div>
                <h1 id='tabelLabel'>Quiz Web</h1>
                <p>
                    This component demonstrates fetching data from the server.
                </p>
                {contents}
            </div>
        );
    }

    async themeData() {
        const response = await fetch('api/theme');
        const data = await response.json();
        this.setState({ themes: data, loading: false });
    }
}
