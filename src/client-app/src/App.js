import MainSidebarBlock from './components/Sidebar/MainSidebarBlock';
import './styles/App.css';
import Content from './components/ContentBlock/Content';

function App() {
  return (
    <div className="App">
        <MainSidebarBlock/>
        <Content/>
    </div>
  );
}

export default App;
